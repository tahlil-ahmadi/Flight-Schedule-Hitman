Feature: FlightGeneration
	In order to generate flights easily and time-efficient
	As an flight agency manager
	I want to be able to generate batch flights

@API @UI
Scenario: Generate flights
	Given I reserved a flight from airline with following information
	| Origin | Destination | From       | To         | FlightNumber |
	| IKA    | DXB         | 2018-09-30 | 2018-10-15 | WS-2130      |
	And The flight has the following weekly timetable
	| DayOfWeek | DepartureTime | ArrivalTime |
	| Monday    | 09:00         | 10:30       |
	| Wednesday | 20:30         | 22:00       |
	When I generate the flights
	Then The following flights should be generated
	| DepartDate       | ArriveDate       | FlightNumber | Origin | Destination |
	| 2018-10-01 09:00 | 2018-10-01 10:30 | WS-2130      | IKA    | DXB         |
	| 2018-10-03 20:30 | 2018-10-03 22:00 | WS-2130      | IKA    | DXB         |
	| 2018-10-08 09:00 | 2018-10-08 10:30 | WS-2130      | IKA    | DXB         |
	| 2018-10-10 20:30 | 2018-10-10 22:00 | WS-2130      | IKA    | DXB         |
	| 2018-10-15 09:00 | 2018-10-15 10:30 | WS-2130      | IKA    | DXB         |
