import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudiosTopWinnersComponent } from './studios-top-winners.component';

describe('StudiosTopWinnersComponent', () => {
  let component: StudiosTopWinnersComponent;
  let fixture: ComponentFixture<StudiosTopWinnersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StudiosTopWinnersComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StudiosTopWinnersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
