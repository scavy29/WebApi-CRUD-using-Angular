import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaymentsService {
  private url='https://8080-bdedfececadfabcaaaceeafebecebbffdafdefabcc.premiumproject.examly.io/api/PaymentDetail';

  
  constructor(private http:HttpClient) { }

  //get all details Service
  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this.url+'/GetPaymentDetail');
  }

  //Create Payment
  Create(data:any){
    let resData:any="";
    let httpHeader:HttpHeaders=new HttpHeaders({
      Accept:"application/json"
    })
    this.http.post("https://8080-bdedfececadfabcaaaceeafebecebbffdafdefabcc.premiumproject.examly.io/api/PaymentDetail/PostPaymentDetail",data,{headers:httpHeader})
    .subscribe(res=>{
      resData=res;
    },
    error=>{
      resData=error
    })
    return resData
  }

  //get details using ID
  getDetailsById(id:number):Observable<any>{
    const url=`${this.url}/GetPaymentDetail/${id}`;
    return this.http.get<any>(url);
  }

  //Delete Details using ID
  deleteById(id:number):Observable<any>{
    const url=`${this.url}/DeletePaymentDetail/${id}`;
    return this.http.delete<any>(url);
  }

  //Update Details Using ID
  UpdateById(id:number,updatedData:any):Observable<any>{
    const url=`${this.url}/UpdatePaymentDetail/${id}`;
    return this.http.put<any>(url,updatedData);
  }
}
