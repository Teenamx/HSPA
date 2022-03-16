import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
import {Routes,RouterModule} from '@angular/router'
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AppComponent } from './app.component';
import { ProductDataComponent } from './product/product-data/product-data.component';
import { ProductlistComponent } from './product/productlist/productlist.component';
import { NavBarComponent } from './product/nav-bar/nav-bar.component';
import { AddPropertyComponent } from './product/add-property/add-property.component';
import {PropertyDetailComponent} from './product/property-detail/property-detail.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component'
import { UserService } from './services/user.service';
import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';
import { PropertyDetailResolverService } from './product/property-detail/property-detail-resolver.service';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { FilterPipe } from './Pipes/filter.pipe';
import { SortPipe } from './Pipes/sort.pipe';
import { HttperrorInterceptorService } from './services/httperror-interceptor.service';

const appRoutes:Routes=[
  {path:'',component:ProductlistComponent},
  {path:'rent-property',component:ProductlistComponent},

  {path:'add-property',component:AddPropertyComponent},
  {path:'property-detail/:id',
  component:PropertyDetailComponent,
  resolve:{prp:PropertyDetailResolverService}},
  {path:'user/login',component:UserLoginComponent},
  {path:'user/register',component:UserRegisterComponent},
   {path:'**',component:ProductlistComponent}
]
@NgModule({
  declarations: [
    AppComponent,
    ProductDataComponent,
    ProductlistComponent,
    NavBarComponent,
    AddPropertyComponent,
    PropertyDetailComponent,
    UserLoginComponent,
    UserRegisterComponent,
    FilterPipe,
    SortPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ButtonsModule.forRoot(),
    BsDatepickerModule.forRoot(),
    NgxGalleryModule
  ],
  providers: [{provide:HTTP_INTERCEPTORS,useClass:HttperrorInterceptorService,multi:true},UserService,AlertifyService,AuthService,PropertyDetailResolverService],
  bootstrap: [AppComponent]
})
export class AppModule { }
