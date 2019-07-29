import cv2
import socket
import sys

import json
import threading
import queue

import numpy as np

import time
import csv

from keras.preprocessing.image import ImageDataGenerator
from keras.models import Sequential, model_from_json
from keras.layers.core import Dense, Dropout, Activation, Flatten
from keras.layers.convolutional import Conv2D
from keras.layers.pooling import MaxPooling2D
from keras.layers.normalization import BatchNormalization
from keras.optimizers import SGD

from sklearn.preprocessing import LabelBinarizer

rspeed = 0
speed = 0
angle = 0
path = 'window_version_Data/Snapshots/fx_UIT_Car.png'

port = 9999
ip = str(sys.argv[1])

width = 160
height = 60

NUM_CLASSES = 75

def cnnModel():
   model = Sequential()
   model.add(BatchNormalization(input_shape=(height, width, 3)))
   model.add(Conv2D(8, (3, 3), activation='relu'))
   model.add(MaxPooling2D(pool_size=(2, 2)))
   model.add(Conv2D(16, (3, 3), activation='relu'))
   model.add(MaxPooling2D(pool_size=(2, 2)))
   model.add(Conv2D(32, (3, 3), activation='relu'))
   model.add(MaxPooling2D(pool_size=(2, 2)))
   model.add(Flatten())
   model.add(Dense(256, activation='linear'))
   model.add(Dense(NUM_CLASSES))
   return model

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
   
   rgb = cv2.cvtColor(thresh, cv2.COLOR_GRAY2RGB)
   return rgb

## Function Parse to Json String
def jsonToString(speed, angle):
   jsonObject = {
      'speed': speed,
      'angle': angle,
      'request': 'SPEED',
   }
   jsonString = json.dumps(jsonObject)
   # print(jsonString)
   return jsonString

## Thread for Socket communication
class socketThread (threading.Thread):
   def __init__(self, threadID, sock):
      threading.Thread.__init__(self)
      self.threadID = threadID
      self.sock = sock
   def run(self):
      global speed
      global angle
      global rspeed
      while(True):
         try:
            print('Speed To Send: ', speed, angle)
            message = jsonToString(speed, int(angle))
            sock.sendall(message.encode())
            data = sock.recv(100).decode('ascii')
            rspeed = int(data)
            print(speed)
         except Exception as e:
            print(e)
            sys.exit(1)

         # time.sleep(2)



## Thread for Processing Image
class processThread (threading.Thread):
   def __init__(self, threadID):
      threading.Thread.__init__(self)
      self.threadID = threadID
   def run(self):
      global speed
      global angle
      # global model
      i = 0
      ####### Get Model ##########
      model = cnnModel()
      model.summary()
      model.load_weights('LaneDetectWeight.h5')
      model.compile(optimizer='adam', loss='mean_squared_error', metrics=['accuracy'])
      while True:
         try:
            img = cv2.imread(path)
            # speed = 70
            # print('speed now is : {0}', rspeed)
            if img is not None:
               processed_img = preprocess(img)
               processed_img = np.expand_dims(processed_img, axis=0)
               predictions = model.predict(processed_img)
               angle = predictions.argmax() - 37
               
               if ((angle < 12) and (angle > -12)):
                  speed = 60
               elif (angle >= 25):
               #   angle = 37
                 speed = 0
               elif (angle <= -25):
               #   angle = -37
                 speed = 0
               else:
                  speed = 10
               # print(angle, speed)
               # cv2.imshow('img', img)
               cv2.waitKey(1)
         except Exception as e:
            print(e)
   cv2.destroyAllWindows()

try:
   sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
   sock.connect((ip , port))
   print("Connected to ", ip, ":", port)

    ## image processing here
except Exception as ex:
   print(ex)
   sys.exit()

threadSendRecv = socketThread(1, sock)
threadProcess = processThread(2)

threadSendRecv.start()
threadProcess.start()

threadProcess.join()
threadSendRecv.join()
