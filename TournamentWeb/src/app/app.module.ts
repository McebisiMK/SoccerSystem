import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Route, Router, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { CaptureComponent } from './capture/capture.component';
import { TournamentsComponent } from './tournaments/tournaments.component';
import { DetailsComponent } from './details/details.component';

const routes: Route[] = [
  { path: 'capture', component: CaptureComponent },
  { path: 'tournaments', component: TournamentsComponent },
  { path: 'tournament/details/:name', component: DetailsComponent }
];
@NgModule({
  declarations: [
    AppComponent,
    CaptureComponent,
    TournamentsComponent,
    DetailsComponent
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
