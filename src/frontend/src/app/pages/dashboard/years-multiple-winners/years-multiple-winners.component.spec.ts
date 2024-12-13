import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YearsMultipleWinnersComponent } from './years-multiple-winners.component';

describe('YearsMultipleWinnersComponent', () => {
  let component: YearsMultipleWinnersComponent;
  let fixture: ComponentFixture<YearsMultipleWinnersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [YearsMultipleWinnersComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(YearsMultipleWinnersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
