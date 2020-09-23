import { TestBed } from '@angular/core/testing';

import { ApiConnectorsService } from './api-connectors.service';

describe('ApiConnectorsService', () => {
  let service: ApiConnectorsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiConnectorsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
