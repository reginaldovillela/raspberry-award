import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMoviesByYearComponent } from './list-movies-by-year.component';

describe('ListMoviesByYearComponent', () => {
  let component: ListMoviesByYearComponent;
  let fixture: ComponentFixture<ListMoviesByYearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListMoviesByYearComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListMoviesByYearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
