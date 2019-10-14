Feature: ParkingChargesComputation
Background: 
Given Following pricing model for parkinglot1
| Name            | PricingType | VehicleType | MinHour | MaxHour | Price |
| TwoWheeler1Hour | Hourly      | 2 Wheeler   | 0       | 1       | 30    |
| TwoWheeler4Hour | 4Hourly     | 2 Wheeler   | 1       | 4       | 100   |
| TwoWheeler1Hour | 24Hourly    | 2 Wheeler   | 4       | 24      | 200   |
| TwoWheeler1Hour | Hourly      | 4 Wheeler   | 0       | 1       | 40    |
| TwoWheeler1Hour | 4Hourly     | 4 Wheeler   | 0       | 4       | 120   |
| TwoWheeler1Hour | 24Hourly    | 4 Wheeler   | 0       | 24      | 350   |

@1
Scenario: When a vehicle leaves with the following details <below 1h>
Given the details of vehicle and timing
| InTime              | OutTime             | VehicleType |
| 2008-09-15T15:53:00 | 2008-09-15T16:45:00 | 4 Wheeler   |
When parking amount computation is launched
Then following should be the price
| Result |
| 40     |

@2
Scenario: When a vehicle leaves with the following details <1h>
Given the details of vehicle and timing
| InTime              | OutTime             | VehicleType |
| 2008-09-15T15:53:00 | 2008-09-15T16:53:00 | 2 Wheeler   |
When parking amount computation is launched
Then following should be the price
| Result |
| 100    |

Scenario: When a vehicle leaves with the following details <more than 24h>
Given the details of vehicle and timing
| InTime              | OutTime             | VehicleType |
| 2008-09-15T15:53:00 | 2008-09-17T16:53:00 | 4 Wheeler   |
When parking amount computation is launched
Then following should be the price
| Result |
| 1000   |
