import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Route, Router, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { CaptureComponent } from './capture/capture.component';
import { TournamentsComponent } from './tournaments/tournaments.component';
import { DetailsComponent } from './details/details.component';
import { TeamsComponent } from './teams/teams.component';
import { TeamCaptureComponent } from './team-capture/team-capture.component';
import { RegistrationComponent } from './registration/registration.component';

const routes: Route[] = [
  { path: 'capture', component: CaptureComponent },
  { path: 'addteam', component: TeamCaptureComponent },
  { path: 'tournaments', component: TournamentsComponent },
  { path: 'teams', component: TeamsComponent },
  { path: 'registration', component: RegistrationComponent },
  { path: 'tournament/details/:id', component: DetailsComponent }
];
@NgModule({
  declarations: [
    AppComponent,
    CaptureComponent,
    TournamentsComponent,
    DetailsComponent,
    TeamsComponent,
    TeamCaptureComponent,
    RegistrationComponent
  ],
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
