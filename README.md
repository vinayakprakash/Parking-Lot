# Parking-Lot
Perched Peacock Parking Lot

It's a complete parking lot management solution  :  
Enables the end users to view the available slots/prices in all the parking lot's.<br />
Enables the operators to log the incoming vehicles and generates prices as per the configuration.<br />
Enables the administrator to configure the different parking lot, pricing models, capacacity based on vehicle type etc.

## Technology Stack

Front End : Angular 8 with Bootstrap 4 <br/>
Back End : .net core 2.1 Web API <br/>
Database : SQLite <br/>
Authentication & Authorization : Uses Firebase to authenticate and custom authorization.

## How to launch

Front End : Go to path https://github.com/vinayakprakash/Parking-Lot/tree/master/UI and run NPM I to install packages and ng serve to run in development mode.<br/>
Rest API : Under https://github.com/vinayakprakash/Parking-Lot/tree/master/Service open ParkingLot.sln in VS 2017 and run <br/>
SQL: Under https://github.com/vinayakprakash/Parking-Lot/tree/master/DB you can find parkinglot.db file, the same has to be referred in https://github.com/vinayakprakash/Parking-Lot/blob/master/Service/ParkingLot/appsettings.json <br/>
Note : https://github.com/vinayakprakash/Parking-Lot/blob/master/FireBase/perchedpeacockparking-firebase.json contains private key for authentication on Web API, same needs to be setup in startup.cs.(In real time scenario it has to be in the deployment server alone)

## Contact
Vinayak.Prakash@live.com
