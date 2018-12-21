import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FlightGenerationRequest } from '../model/flight-generation-request';
import { WeeklyTimetable } from '../model/weekly-timetable';

@Component({
  selector: 'weekly-timetable',
  templateUrl: './weekly-timetable.component.html',
})
export class WeeklyTimetableComponent {
  @Input() data: Array<WeeklyTimetable>;
  @Output() dataChange: EventEmitter<Array<WeeklyTimetable>>;

  constructor() {
    this.dataChange = new EventEmitter<Array<WeeklyTimetable>>();
  }

  add() {
    this.data.push(new WeeklyTimetable());
  }
}
