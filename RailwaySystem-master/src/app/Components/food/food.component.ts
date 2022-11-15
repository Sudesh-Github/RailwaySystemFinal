import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { food } from 'src/app/Models/food.model';
import { SharedService } from 'src/app/shared.service';
import { FooterService } from 'src/app/SharedService/footer.service';

@Component({
  selector: 'app-food',
  templateUrl: './food.component.html',
  styleUrls: ['./food.component.css']
})

export class FoodComponent implements OnInit 
{
  formValue!:FormGroup;
  submitted=false;
  userID!:any;

  get foodType() {
    return this.formValue.get('foodType');
  }
  get IsNeeded() {
    return this.formValue.get('isNeeded');
  }
  
  constructor(private fs:FooterService,private shared:SharedService,private fb:FormBuilder,private router:Router) { }

  ngOnInit(): void {
    this.fs.show();
    this.formValue=this.fb.group({
      foodType:['',Validators.required] ,
      IsNeeded:['',Validators.required]
    });
  }



    fModel:food = new food(); 
    fData!:any;
    food:string;

  addFood() {

    this.submitted=false;
    let user:any=localStorage.getItem("userId");
    this.userID=JSON.parse(user);
    this.fModel.foodType=this.formValue.value.foodType;
    this.fModel.isNeeded=this.formValue.value.isNeeded;
  
    this.shared.addFood(this.fModel).subscribe((res)=>{
      console.log(res);
      
      localStorage.setItem("food",JSON.stringify(res));
      var json=localStorage.getItem("food")as string;
      var storeData= JSON.parse(json);
      console.log(storeData.PName);
      this.router.navigateByUrl('/login/user/dashboard/booking');


  });
}


}