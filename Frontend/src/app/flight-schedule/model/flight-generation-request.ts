import { WeeklyTimetable } from './weekly-timetable';

export class FlightGenerationRequest {
    origin: string;
    destination: string;
    from: string;
    to: string;
    flightNumber: string;
    timetables: Array<WeeklyTimetable>;

    constructor() {
        this.timetables = new Array<WeeklyTimetable>();
    }
}

