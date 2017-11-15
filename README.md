# flightView
Displays flight sticks and pedals that can be used with streaming and video recording services

This is a work in progress application that was made to work with OBS to record the position of flightstick and pedals.

## Installation

The steps listed below were created specifically for integration with Star Citizen and OBS Studio.
This application could be used with other streaming or recording programs, however installation will not be covered here. 

* Star citizen must be in window mode, follow the instructions below for fullscreen window mode
* Download the .exe from the link below
* Unplug all the controllers from your usb ports
* Start the flightView.exe
* Plug in the flights sticks starting with Left Hand Stick then Right Hand Stick then Pedals
* Start OBS
* Set the window capture to the flightView window
* Add a filter for Chroma Key

## Star Citizen in fullscreen windowless mode

* Add USER.cfg to Cloud Imperium Games\StarCitizen\Public folder
* In the USER.cfg file add r_FullscreenWindow = 1
* Start star citizen

## Agenda list

Currently the app has zero settings, but here a few of the major components I will be adding.

- [ ] Customize color scheme
- [ ] Customize position
- [ ] Ability to set controller to UI element
