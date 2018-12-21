import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';

import { FlightGenerationComponent } from './flight-schedule/flight-generation/flight-generation.component';
import { WeeklyTimetableComponent } from './flight-schedule/weekly-timetable/weekly-timetable.component';
import { FlightGenerationService } from './flight-schedule/services/flight-generation.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,

    FlightGenerationComponent,
    WeeklyTimetableComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    FlightGenerationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
