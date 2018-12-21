import { Injectable } from '@angular/core';
import { FlightGenerationRequest } from '../model/flight-generation-request';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class FlightGenerationService {

    constructor(private http: HttpClient) { }

    save(model: FlightGenerationRequest): Observable<any>  {
        return this.http.post('http://localhost:21000/api/Flights', model);
    }

}
