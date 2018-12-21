import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FlightGenerationRequest } from '../model/flight-generation-request';
import { WeeklyTimetable } from '../model/weekly-timetable';
import { WeekDay } from '@angular/common';

@Component({
  selector: 'weekly-timetable',
  templateUrl: './weekly-timetable.component.html',
})
export class WeeklyTimetableComponent {
  @Input() data: Array<WeeklyTimetable>;
  @Output() dataChange: EventEmitter<Array<WeeklyTimetable>>;

  days = [
    {key:0,value:"Sunday"},
    {key:1,value:"Monday"},
    {key:2,value:"Tuesday"},
    {key:3,value:"Wednesday"},
    {key:4,value:"Thursday"},
    {key:5,value:"Friday"},
    {key:6,value:"Saturday"}
  ]

  constructor() {
    this.dataChange = new EventEmitter<Array<WeeklyTimetable>>();
  }

  add() {
    this.data.push(new WeeklyTimetable());
  }
}
