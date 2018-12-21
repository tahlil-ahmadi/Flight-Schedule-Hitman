import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { FlightGenerationComponent } from './flight-generation.component';
import { FormsModule } from '@angular/forms';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { FlightGenerationService } from '../services/flight-generation.service';
import { By } from '@angular/platform-browser';

describe('flightGeneration component', () => {

    let sutFixture: ComponentFixture<FlightGenerationComponent>;

    beforeEach(() => {
        const fakeService = jasmine.createSpyObj(['save']);

        TestBed.configureTestingModule({
            declarations: [
                FlightGenerationComponent
            ],
            imports: [
                FormsModule
            ],
            providers: [
                {provide: FlightGenerationService, useValue: fakeService}
            ],
            schemas: [NO_ERRORS_SCHEMA]
        });
        sutFixture = TestBed.createComponent(FlightGenerationComponent);
    });

    it('should bind #destination to proper input', fakeAsync(() => {
        sutFixture.componentInstance.model.origin = 'IKA';
        sutFixture.detectChanges();
        tick();
        const originElement = sutFixture.debugElement.query(By.css('#originInput')).nativeElement;
        expect(originElement.value).toBe('IKA');
    }));

});
