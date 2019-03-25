import { TestBed } from '@angular/core/testing';

import { ServicestackAuthService } from './servicestack-auth.service';

describe('ServicestackAuthService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ServicestackAuthService = TestBed.get(ServicestackAuthService);
    expect(service).toBeTruthy();
  });
});
