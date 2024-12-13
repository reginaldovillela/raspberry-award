import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProducersWinMinMaxComponent } from './producers-win-min-max.component';

describe('ProducersWinMinMaxComponent', () => {
  let component: ProducersWinMinMaxComponent;
  let fixture: ComponentFixture<ProducersWinMinMaxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProducersWinMinMaxComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProducersWinMinMaxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
