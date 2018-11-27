import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { TeamCaptureComponent } from "./team-capture.component";

describe("TeamCaptureComponent", () => {
  let component: TeamCaptureComponent;
  let fixture: ComponentFixture<TeamCaptureComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TeamCaptureComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamCaptureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
