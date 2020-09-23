import { TestBed } from '@angular/core/testing';

import { CollectStaffDataService } from './collect-staff-data.service';

describe('CollectStaffDataService', () => {
  let service: CollectStaffDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CollectStaffDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
