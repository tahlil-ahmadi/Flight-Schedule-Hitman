import { Component } from '@angular/core';
import { FlightGenerationRequest } from '../model/flight-generation-request';
import { FlightGenerationService } from '../services/flight-generation.service';

@Component({
  selector: 'flight-generation',
  templateUrl: './flight-generation.component.html',
})
export class FlightGenerationComponent {
  model: FlightGenerationRequest;
  isLoading:boolean;
  constructor(private service: FlightGenerationService) {
    this.model = new FlightGenerationRequest();
  }

  save() {
    this.isLoading= true;
    this.service.save(this.model).subscribe(a=>{
      this.isLoading = false;
    });
  }
}
