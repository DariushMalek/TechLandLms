import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteEntityModalComponentComponent } from './delete-entity-modal-component.component';

describe('DeleteEntityModalComponentComponent', () => {
  let component: DeleteEntityModalComponentComponent;
  let fixture: ComponentFixture<DeleteEntityModalComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteEntityModalComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteEntityModalComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
