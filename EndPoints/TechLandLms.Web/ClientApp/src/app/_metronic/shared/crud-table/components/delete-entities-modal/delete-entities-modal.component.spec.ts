import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteEntitiesModalComponent } from './delete-entities-modal.component';

describe('DeleteEntitiesModalComponent', () => {
  let component: DeleteEntitiesModalComponent;
  let fixture: ComponentFixture<DeleteEntitiesModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteEntitiesModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteEntitiesModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
