import { Component, CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './Components/footer/footer.component';
import { HomeComponent } from './Components/home/home.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { SharedServicesService } from './SharedService/shared-services.service';
import { Router,RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatIconModule} from '@angular/material/icon';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { UserDashboardComponent } from './Components/user-dashboard/user-dashboard.component';
import { AboutUsComponent } from './Components/about-us/about-us.component';
import { ContactUsComponent } from './Components/contact-us/contact-us.component';
import { SignupComponent } from './Components/signup/signup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TrainsComponent } from './Components/trains/trains.component';
import { LoginComponent } from './Components/login/login.component';
import { AuthGuard } from './Auth/auth.guard';
import { AddPassengerComponent } from './Components/add-passenger/add-passenger.component';
import { MatRadioModule} from '@angular/material/radio';
import { MatFormFieldModule } from '@angular/material/form-field'; 
import{MatSelectModule}from'@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import{MatInputModule}from '@angular/material/input';
import { BookingComponent } from './Components/user-dashboard/booking/booking.component';
import { TransactionComponent } from './Components/user-dashboard/transaction/transaction.component';
import { UserNavComponent } from './Components/user-dashboard/user-nav/user-nav.component';
import { TicketComponent } from './Components/user-dashboard/ticket/ticket.component';
import { BookingHistoryComponent } from './Components/user-dashboard/booking-history/booking-history.component';
import { StationComponent } from './Components/user-dashboard/station/station.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    FooterComponent,
    HomeComponent,  
    UserDashboardComponent,
    AboutUsComponent,
    ContactUsComponent,
    SignupComponent,
    TrainsComponent,
    LoginComponent,
    AddPassengerComponent,
    BookingComponent,
    TransactionComponent,
    UserNavComponent,
    TicketComponent,
    BookingHistoryComponent,
    StationComponent 
   
   
  ],
  imports: [
    BrowserModule,
    [ FormsModule, ReactiveFormsModule],
    RouterModule.forRoot ([
      {path:'home', component:HomeComponent},
      // {path:'admin-dashboard', component:AdminDashboardComponent},
      {path:'sign-up', component:SignupComponent},
      {path:'login/user/dashboard/trains', component:TrainsComponent,canActivate:[AuthGuard]},
    
      {path:'login/user/dashboard/add-passenger', component:AddPassengerComponent,canActivate:[AuthGuard]},
      {path:'login/user/dashboard/booking',component:BookingComponent,canActivate:[AuthGuard]},
      {path:'login/user/dashboard/ticket',component:TicketComponent,canActivate:[AuthGuard]},
      {path:'login/user/dashboard/transaction',component:TransactionComponent,canActivate:[AuthGuard]},
      {path:'login/user/dashboard/booking-history',component:BookingHistoryComponent,canActivate:[AuthGuard]},
      {path: '', redirectTo: 'home', pathMatch: 'full'},
      {path:'signup', component:SignupComponent},
      {path:'login', component:LoginComponent},
      {path:'login/user/dashboard/station', component:StationComponent, canActivate:[AuthGuard]},
      {path:'login/user/dashboard', component:UserDashboardComponent, canActivate:[AuthGuard]},
     ]),
     
     HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatDatepickerModule,
    MatRadioModule,
    MatSelectModule,
    MatFormFieldModule,
    MatOptionModule,
    BrowserModule,
    NgbModule,
    MatInputModule
  ],
  providers: [SharedServicesService ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
