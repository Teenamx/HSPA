import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { UserForRegistration } from 'src/app/model/user';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {

  registrationForm: FormGroup;
  user:UserForRegistration;
  userSubmitted:boolean;
  constructor(private fb:FormBuilder,
    private authService:AuthService,
    private alertify:AlertifyService) { }

  ngOnInit(): void {
   /*  this.registrationForm=new FormGroup(
      {
        userName:new FormControl('Teena',Validators.required),
        email:new FormControl(null,[Validators.required,Validators.email]),
        password:new FormControl(null,[Validators.required,Validators.minLength(5)]),
        confirmPassword:new FormControl(null,[Validators.required]),
        mobile:new FormControl(null,Validators.maxLength(10))
      },
      this.passwordMatchingValidator
    ) */
    this.createRegistrationForm();
  }
  createRegistrationForm()
  {
    this.registrationForm=this.fb.group({
      userName:[null,Validators.required],
      email:[null,[Validators.required,Validators.email]],
      password:[null,[Validators.required,Validators.minLength(8)]],
      confirmPassword:[null,[Validators.required]],
      mobile:[null,[Validators.maxLength(10),Validators.required]]
    },{validators:this.passwordMatchingValidator})
  }

  onSubmit()
  {
    this.userSubmitted=true;
    if(this.registrationForm.valid)
    {
    console.log(this.registrationForm);
   // this.user=Object.assign(this.user,this.registrationForm.value);
    this.authService.registerUser(this.userData()).subscribe(()=>
    {
      this.onReset();
     this.alertify.success("congrats, you are successfully registered");
    }
   /*  ,
    error=>{
      console.log(error);
      this.alertify.error(error.error);
    } */

    );

   }

   /*  else
    {
      this.alertify.error("Kindly provide required fields");

    } */
   // localStorage.setItem('Users',JSON.stringify(this.user));
  }
  onReset()
  {
    this.userSubmitted=false;
    this.registrationForm.reset();
  }
  userData():UserForRegistration
  {
    return this.user={
     userName:this.userName.value,
     email:this.email.value,
     password:this.password.value,
     mobile:this.mobile.value
    }

  }
  passwordMatchingValidator(fc:AbstractControl):ValidationErrors | null
  {
    return fc.get('password')?.value===fc.get('confirmPassword')?.value?null:{notmatched:true}
  }
  get userName()
  {
    return this.registrationForm.get('userName') as FormControl;
  }
  get email()
  {
    return this.registrationForm.get('email') as FormControl;
  }
  get password()
  {
    return this.registrationForm.get('password') as FormControl;
  }
  get confirmPassword()
  {
    return this.registrationForm.get('confirmPassword') as FormControl;
  }
  get mobile()
  {
    return this.registrationForm.get('mobile') as FormControl;
  }
 /*  addUser(user)
  {
    let users=[];
    if(localStorage.getItem('Users'))
    {
      users=JSON.parse(localStorage.getItem('Users'));
      users=[user,...users];
    }
    else{
      users=[user];
    }

    /* console.log(JSON.stringify(user));
     users = JSON.parse(localStorage.getItem('Users')) || [];
    console.log(JSON.stringify(users) );
    users.push(JSON.stringify(user)); */
    // localStorage.setItem('Users',JSON.stringify(users));
 // } */

}
