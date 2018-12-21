import { FlightGenerationService } from "./flight-generation.service";
import { FlightGenerationRequest } from "../model/flight-generation-request";


describe('flightGeneration service ', () => {

    let httpClient;
    let sut: FlightGenerationService;

    beforeEach(() => {
        httpClient = jasmine.createSpyObj(['post']);
        sut = new FlightGenerationService(httpClient);
    });

    it('#save() should post model', () => {
        const expectedUrl = 'http://localhost:21000/api/Flights';
        const model = new FlightGenerationRequest();

        sut.save(model);

        expect(httpClient.post).toHaveBeenCalled();
        expect(httpClient.post).toHaveBeenCalledWith(expectedUrl, model);
    });
});
