import cv2
import numpy as np
import deviationFromSobel
#import deviationRC
# import detectSign
import sys
#sys.path.append('/driver')

from termcolor import colored
import time

path = 'window_version_Data/Snapshots/fx_UIT_Car.png'

global rgb_stream
#Frame 640 x 480

def initialize():
	openni2.initialize()     # can also accept the path of the OpenNI redistribution
	
	dev = openni2.Device.open_any()
	print(dev.get_device_info())

	rgb_stream = dev.create_color_stream()

	print('The rgb video mode is', rgb_stream.get_video_mode()) # Checks rgb video configuration
	rgb_stream.set_video_mode(c_api.OniVideoMode(pixelFormat=c_api.OniPixelFormat.ONI_PIXEL_FORMAT_RGB888, resolutionX=640, resolutionY=480, fps=30))

	## Start the streams
	rgb_stream.start()
	
	return rgb_stream

def main():
	print("Hello World!")
	
	#orig_settings = termios.tcgetattr(sys.stdin)
	
	#tty.setraw(sys.stdin)
	x = 0
	
	running = 0
	
	# rgb_stream = initialize()
	devi = deviationFromSobel.deviation()
  
	#cap = cv2.VideoCapture('video.mp4')
	while True:
		try:
			img = cv2.imread(path)
			# img = cv2.flip(img, 1 )
			#ret,img = cap.read()
			#img = cv2.resize(img, (640, 480))
			#mask = sign.getMask(img)
			#sign.getLowerUpper()
			angle = devi.process_image(img)
			#driver.setSpeed(0)
			print(int(angle))
		
		
		
			if cv2.waitKey(1)& 0xFF == ord('q'):
				break
		except Exception as e:
			print(e)
	  
	  #if x == ord('q'):
		  #break
		
	#driver.setSpeed(0)
	cap.release()
	cv2.destroyAllWindows()
	#termios.tcsetattr(sys.stdin, termios.TCSADRAIN, orig_settings)
	
def stop():
	driver = driverLib.DRIVER()
	driver.turnOnLed1()
	driver.turnOffLed2()
	driver.turnOnLed3()
	driver.setAngle(0)
	driver.setSpeed(0)
	print(colored('program crash', 'red'))
	print(colored('stopped motor', 'green'))
	return
    
if __name__== "__main__":
  try:
	  main()
  except:
	  pass
	#   stop()

