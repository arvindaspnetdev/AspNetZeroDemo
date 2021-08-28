import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CountryServiceProxy,
  CountryDto, 
  CreateCountryDto
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';
@Component({ 
  templateUrl: './create-country-dialog.component.html' 
})
export class CreateCountryDialogComponent  extends AppComponentBase
implements OnInit {
  saving = false;
  country = new CreateCountryDto();

  
  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _countryService: CountryServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }
  ngOnInit(): void {
     
  }
  save(): void {
    this.saving = true;
    const country = new CreateCountryDto();
    country.init(this.country);
debugger
    this._countryService
      .create(country)
      .subscribe(
        () => {
          this.notify.info(this.l('SavedSuccessfully'));
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        () => {
          this.saving = false;
        }
      );
  }
}
