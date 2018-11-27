import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { Route, Router, RouterModule } from "@angular/router";
import { HttpClientModule } from "@angular/common/http";
import { AppComponent } from "./app.component";
import { FormsModule } from "@angular/forms";
import { CaptureComponent } from "./tournament-capture/capture.component";
import { DetailsComponent } from "./registrations/details.component";
import { TeamCaptureComponent } from "./team-capture/team-capture.component";

const routes: Route[] = [
  { path: "captureTournament", component: CaptureComponent },
  { path: "captureTeam", component: TeamCaptureComponent },
  { path: "tournament/details/:id", component: DetailsComponent }
];
@NgModule({
  declarations: [
    AppComponent,
    CaptureComponent,
    DetailsComponent,
    TeamCaptureComponent
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
export class AppModule {}
