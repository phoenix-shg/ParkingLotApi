### Parking Lot ASP.NET Core web API
#### Story1:

As the boss of a parking lot start-up company, I need a Web managment system to manage my parking lots. Now I sincerely invite your team to develop this system. There will be impressive rewards.

**AC1**: If I buy a new parking lot, I can add a parking lot on the system interface. The information I need to input include:
- name(unique)
- capacity(cannot be minus)
- location

**AC2**: If the parking lot has been sold to others, I can delete this parking lot in the system.

**AC3**: I can check anytime the parking lot list on the system interface. For reading convenience, I'd like to see the information shown by pages, with 15 items on one page.

**AC4**: I can also click a specific parking lot to see its details.

**AC5**: The surrounding area of my parking lot is under reconstruction. After the surrounding buildings are demolished, I can expand my parking lot's capacity. So I also need to update the capacity information in the system.

----------

#### Story2:
To improve the parking experience, I have bought an automatic plate number detecting access control system. It has a monitor and can detect a car's plate number. When there are free space in the parking lot, it will let the car in. If the parking lot is full, it will inform the car and deny the entrance.

**AC1**: When a customer comes to Parking Lot NO.1, if there is free space, the system will create a parking order and lift up the entrance. The order will include below information:
- Order number
- Name of parking lot
- Plate number
- Creation time(the time when a car enters)
- Close time(the time when a car leaves)
- Order status(open as default status)

**AC2**: When a customer leaves Parking Lot NO.1, the system will update the order status with this car. The leaving time will be recorded as its order close time and the order status updated to close.

**AC3**: When a customer wants to park in Parking Lot No.1, if the parking lot is full, parking order creation will fail, with the system monitor showing the message "The parking lot is full".

-------------

##### In Scope
1. Use RESTful API to communicate
2. Use Entity Framework Core Migration to manage database

##### Out of Scope
1. Logic of front-end page
2. Logic of system monitor
