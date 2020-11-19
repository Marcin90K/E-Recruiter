import { BehaviorSubject, Observable } from 'rxjs';
import { JobOfferVM } from 'src/app/shared/models/job-offer/job-offer-vm';
import { Injectable } from '@angular/core';
import { JobOfferForUpdate } from '../models/job-offer/job-offer-for-update';
import { JobOfferUpdated } from '../models/job-offer/job-offer-updated';

@Injectable({
  providedIn: 'root'
})
export class JobOfferSharingDataService {

  private jobOffer = new BehaviorSubject<JobOfferVM>(null);

  constructor() { }

  updateJobOfferData(jobOffer: JobOfferVM) {
    this.jobOffer.next(jobOffer);
  }

  getJobOfferData(): Observable<JobOfferVM> {
    return this.jobOffer.asObservable();
  }

  clearAll() {
    this.jobOffer.next(null);
  }
}
