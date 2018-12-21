import { Component } from '@angular/core';
import { FlightGenerationRequest } from '../model/flight-generation-request';
import { FlightGenerationService } from '../services/flight-generation.service';

@Component({
  selector: 'flight-generation',
  templateUrl: './flight-generation.component.html',
})
export class FlightGenerationComponent {
  model: FlightGenerationRequest;
  constructor(private service: FlightGenerationService) {
    this.model = new FlightGenerationRequest();
  }

  save() {
    this.service.save(this.model).subscribe();
  }
}
