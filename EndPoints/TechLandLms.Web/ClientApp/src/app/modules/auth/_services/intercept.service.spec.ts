import { TestBed } from '@angular/core/testing';

import { InterceptServiceService } from './intercept-service.service';

describe('InterceptServiceService', () => {
  let service: InterceptServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InterceptServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
