import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ToYesNoPipe } from './pipes/to-yes-no.pipe';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ListComponent } from './pages/list/list.component';
import { StudiosTopWinnersComponent } from './pages/dashboard/studios-top-winners/studios-top-winners.component';
import { TopBarComponent } from './components/top-bar/top-bar.component';
import { YearsMultipleWinnersComponent } from './pages/dashboard/years-multiple-winners/years-multiple-winners.component';
import { ListMoviesByYearComponent } from './pages/dashboard/list-movies-by-year/list-movies-by-year.component';
import { ProducersWinMinMaxComponent } from './pages/dashboard/producers-win-min-max/producers-win-min-max.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    ListComponent,
    ToYesNoPipe,
    StudiosTopWinnersComponent,
    TopBarComponent,
    YearsMultipleWinnersComponent,
    ListMoviesByYearComponent,
    ProducersWinMinMaxComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
