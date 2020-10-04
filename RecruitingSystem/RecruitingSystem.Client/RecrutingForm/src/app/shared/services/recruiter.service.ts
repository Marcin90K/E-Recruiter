import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { APPLICATION_MODULE_PROVIDERS } from '@angular/core/src/application_module';
import { RecruiterVM } from '../models/recruiter/recruiter-vm';
import { Observable } from 'rxjs';
import { RecruiterListVM } from '../models/recruiter/recruiter-list-vm';

@Injectable({
  providedIn: 'root'
})
export class RecruiterService {

  private baseUrl: string;
  private section = 'recruiter';
  private searchParam = 'search';
  private pageNumber = 'pageNumber';
  private pageSize = 'pageSize';

  constructor(private http: HttpClient) {
    this.baseUrl = environment.API_URL + this.section;
  }


  getRecruiter(id: string): Observable<RecruiterVM> {
    let url = this.baseUrl + '/' + id;
    return this.http.get<RecruiterVM>(url);
  }

  getRecruiters(search = '' , pageNumber = 1, pageSize = 10): Observable<RecruiterListVM> {
    const options = {
      params: new HttpParams().set(this.searchParam, search)
                          .set(this.pageNumber, pageNumber.toString())
                          .set(this.pageSize, pageSize.toString())
    };
    return this.http.get<RecruiterListVM>(this.baseUrl, options);
  }

}
