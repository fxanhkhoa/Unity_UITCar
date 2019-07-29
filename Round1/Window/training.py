#!/usr/bin/env python
# coding: utf-8

# In[1]:


import os
import cv2
import numpy as np
import glob
import matplotlib.pyplot as plt
import h5py
from keras.preprocessing.image import ImageDataGenerator
from keras.models import Sequential, model_from_json
from keras.layers.core import Dense, Dropout, Activation, Flatten
from keras.layers.convolutional import Conv2D
from keras.layers.pooling import MaxPooling2D
from keras.layers.normalization import BatchNormalization
from keras.optimizers import SGD

from keras.utils import to_categorical
from sklearn.preprocessing import LabelBinarizer

import csv
import sys


# In[2]:


width = 160
height = 60
np.set_printoptions(threshold=sys.maxsize)


# In[3]:


def preprocess(img):
    new_img = img[300:480, 0:640]
    hsv = cv2.cvtColor(new_img, cv2.COLOR_BGR2HSV)
    lower = np.uint8([83, 0, 0])
    upper = np.uint8([179, 47, 255])
    white_mask = cv2.inRange(hsv, lower, upper)

    result = cv2.bitwise_and(new_img, new_img, mask = white_mask)
#     print(img)
    result = cv2.resize(result, (width, height))
    gray = cv2.cvtColor(result, cv2.COLOR_BGR2GRAY)
    ret, thresh = cv2.threshold(gray ,150 ,255, cv2.THRESH_BINARY_INV)
    plt.imshow(thresh)
    
    rgb = cv2.cvtColor(thresh, cv2.COLOR_GRAY2RGB)
#     print(rgb.shape)
#     cv2.imshow('thresh',thresh)
#     cv2.waitKey(1)
    return rgb


# In[4]:


def get_class(img_path):
#     print(img_path.split('\\')[-2])
    return (img_path.split('\\')[-2])


# In[5]:


NUM_CLASSES = 75
try:
    with h5py.File('datasetCNN.h5') as hf:
        X, Y = hf['imgs'][:], hf['labels'][:]
    print("Loaded images from datasetCNN.h5")
    print(X.shape)
    print(Y.shape)
except Exception as e:
    
    imgs = []
    labels = []
    i = 0
    with open('datasetTrain.csv', mode='r', newline = '') as csv_file:
        csv_reader = csv.DictReader(csv_file)
        for row in csv_reader:        
#             print(row["image_name"])
            path = row["image_name"].replace('images', 'imagesTrain')
            img = preprocess(cv2.imread(path))
            imgs.append(img)

            labels.append(row["angle"])
    
    X = np.array(imgs, dtype='uint8')
    #Y = np.eye(NUM_CLASSES, dtype='int')[labels]
    Y = np.array(labels)
#     print(Y)

    encoder = LabelBinarizer()
    #Y = to_categorical(labels)
    Y = encoder.fit_transform(labels)
#     print(Y)
    print(Y.shape)
    with h5py.File('datasetCNN.h5','w') as hf:
        hf.create_dataset('imgs', data=X)
        hf.create_dataset('labels', data=Y)


# In[6]:



def cnnModel():
    model = Sequential()
    model.add(BatchNormalization(input_shape=(height, width, 3)))
#     model.add(Conv2D(32, (3,3), padding='same',
#                     input_shape=(height, width, 3),
#                     activation='relu'))
#     model.add(MaxPooling2D(pool_size=(2, 2)))
    model.add(Conv2D(8, (3, 3), activation='relu'))
    model.add(MaxPooling2D(pool_size=(2, 2)))
    model.add(Conv2D(16, (3, 3), activation='relu'))
    model.add(MaxPooling2D(pool_size=(2, 2)))
    model.add(Conv2D(32, (3, 3), activation='relu'))
    model.add(MaxPooling2D(pool_size=(2, 2)))
    model.add(Flatten())
#     model.add(Dense(512, activation='linear'))
    model.add(Dense(256, activation='linear'))
#     model.add(Dropout(0.2))
#     model.add(Dense(128, activation='linear'))
#     model.add(Dense(64, activation='linear'))
    model.add(Dense(NUM_CLASSES))
    return model


# In[7]:


model = cnnModel()
lr = 0.01
sgd = SGD(lr=lr, decay=1e-6, momentum=0.9, nesterov=True)
# model.compile(loss='categorical_crossentropy',
#                   optimizer=sgd,
#                   metrics=['accuracy'])
model.compile(optimizer='adam', loss='mean_squared_error', metrics=['accuracy'])
model.summary()


# In[8]:


batch_size = 64
nb_epoch = 30
model.fit(X, Y, batch_size=batch_size, epochs=nb_epoch)
model.save_weights('LaneDetectWeight.h5')


# In[9]:


# array_text = [-10, -15, -20, 25, -30, -5, 0, 10, 15, 20, 25, 30, 5]
# array_text = [-44, -36, -35, -34, -33, -32, -31, -30, -29, -28, -27, -26, -25, -24]
test_img = cv2.imread('imagesTest/20.png')
predict_img = preprocess(test_img)
# predict_img = np.array(predict_img, dtype='uint8')
predict_img = np.expand_dims(predict_img, axis=0)
result = model.predict(predict_img)
# print(array_text[result.argmax()])
if result.argmax() == 0:
    print('-44')
elif result.argmax() == 74:
    print('44')
print(result.argmax() - 37)


# In[10]:


imgs = []
labels = []
i = 0
with open('datasetTest.csv', mode='r', newline = '') as csv_file:
    csv_reader = csv.DictReader(csv_file)
    for row in csv_reader:        
#         print(row["image_name"])
        path = row["image_name"].replace('images', 'imagesTest')
        img = preprocess(cv2.imread(path))
        imgs.append(img)

        labels.append(row["angle"])

X = np.array(imgs, dtype='uint8')
#Y = np.eye(NUM_CLASSES, dtype='int')[labels]
Y = np.array(labels, dtype='int8')
#     print(Y)

y_pred = model.predict_classes(X)
print(y_pred - 37)
print(Y)
acc = np.sum(y_pred-37 == Y)/np.size(y_pred)
print(acc)


# In[ ]:




