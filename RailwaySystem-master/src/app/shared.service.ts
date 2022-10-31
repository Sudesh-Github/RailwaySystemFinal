import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { User } from './Components/signup/signup.model';
import { passenger } from './Models/passenger.model';
import { Train } from './Models/train.model';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  public userServices:User;
  public TrainS:Train;
  public Passenger:passenger;
  readonly APIUrl ="https://localhost:44379/api"
  constructor(private http:HttpClient ) { }

  SaveUser(val:any){
    console.log(val);
    return this.http.post<any>(this.APIUrl+'/User/SaveUser',val)
  }
  getUserProfile(){
    var tokenHeader = new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')})
    console.log(tokenHeader);
    return this.http.get(this.APIUrl+'/User/GetUserProfile', {headers : tokenHeader});
  }
  //Trains
  getAllTrains():Observable<Train>{
    return this.http.get<Train>(this.APIUrl+'/Train/GetAllTrains');
    
  }

  saveTrain(val:any){
    return this.http.post<Train>(this.APIUrl+'/Train/SaveTrain',val);
  }
  deleteTrain(id:number){
    return this.http.delete<Train>(this.APIUrl+'/Train/DeleteTrain?TrainId='+id);
  }
  updateTrain(data:any){
    return this.http.put<any>(this.APIUrl+'/Train/UpdateTrain',data);
  }
  SearchTrain(arr:any,dept:any,date:any){
    return this.http.get<Train>(this.APIUrl+'/Train/SearchTrainsSeat2?ArrivalStation='+arr+'&DepartureStation='+dept+'&date='+date);

  }
  

  
  updateSeats(id:number,data:any){
    return this.http.put<any>(this.APIUrl+'/Seat/UpdateSeat?SeatId='+id,data);

  }
  
 
  Login(formData: any){
    console.log(formData);
    return this.http.post<User>(this.APIUrl+'/User/login',formData)
  }
  GetUserbyEmail(email:any){
    return this.http.get<User>(this.APIUrl+'/User/GetUserbyEmail?Email=')
  }
  getAllUserDetails():Observable<any[]>{
    return this.http.get<any[]>(this.APIUrl+'/User/GetAllUser()')
    }
  getTrainbyId(id:number){
    return this.http.get<Train>(this.APIUrl+'/Train/GetTrain?TrainId='+id)
  }
  EmailService(name:any,reciever:any){
    // console.log(name);
    // console.log(reciever);
    return this.http.get<User>(this.APIUrl+'/User/EmailService?name='+name+'&reciever='+reciever);
  }


  //Passenger

  addPassenger(val:any){
    return this.http.post<passenger>(this.APIUrl+'/Passenger/AddPassenger',val);
  }
  report(tid:number){
    return this.http.get<any>(this.APIUrl+'/Passenger/GetReport?TrainId='+tid);
  }

  //fare
  fareCal(tid:number,val:any,pid:number,uid:number){
    return this.http.get<any>(this.APIUrl+'/Booking/CalculateFare?TrainId='+tid+'&Class='+val+'&PassengerId='+pid+'&UserId='+uid);
  }

  //booking
  bookingHistory(uid:number){
      return this.http.get<any>(this.APIUrl+'/Booking/GetBookingHistory?UserId='+uid);
  }
  DelbookingHistory(bid:number){
    return this.http.delete<any>(this.APIUrl+'/Booking/DeleteBooking?BookingId='+bid);
  }
  getBookingbyId(bid:number){
    return this.http.get<any>(this.APIUrl+'/Booking/GetBooking?BookingId='+bid);
  }
  //Transaction
  GetBookingId(pid:number){
    return this.http.get<any>(this.APIUrl+'/Booking/GetBookingId?PassengerId='+pid);
  }
  confirmBooking(bid:any){
    return this.http.get<any>(this.APIUrl+'/Booking/ConfirmBooking?BookingId='+bid);
  }
}

