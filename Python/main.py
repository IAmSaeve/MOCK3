from sense_hat import SenseHat
import time

s = SenseHat()
s.low_light = True

degrees = 0

g = (0, 255, 0)
b = (0, 0, 255)
r = (255, 0, 0)
white = (255,255,255)
nothing = (0,0,0)

green = [
  g, g, g, g, g, g, g, g,
  g, g, g, g, g, g, g, g,
  g, g, g, g, g, g, g, g,
  g, g, g, g, g, g, g, g,
  g, g, g, g, g, g, g, g,
  g, g, g, g, g, g, g, g,
  g, g, g, g, g, g, g, g,
  g, g, g, g, g, g, g, g,
]

blue = [
  b, b, b, b, b, b, b, b,
  b, b, b, b, b, b, b, b,
  b, b, b, b, b, b, b, b,
  b, b, b, b, b, b, b, b,
  b, b, b, b, b, b, b, b,
  b, b, b, b, b, b, b, b,
  b, b, b, b, b, b, b, b,
  b, b, b, b, b, b, b, b,
]

red = [
  r, r, r, r, r, r, r, r,
  r, r, r, r, r, r, r, r,
  r, r, r, r, r, r, r, r,
  r, r, r, r, r, r, r, r,
  r, r, r, r, r, r, r, r,
  r, r, r, r, r, r, r, r,
  r, r, r, r, r, r, r, r,
  r, r, r, r, r, r, r, r,
]

while True:
  degrees = s.get_temperature()
  print(degrees)
  if degrees < 18:
    s.set_pixels(blue)
  elif degrees >= 18 and degrees <= 22:
    s.set_pixels(green)
  elif degrees > 22:
    s.set_pixels(red)
    
    
    
    