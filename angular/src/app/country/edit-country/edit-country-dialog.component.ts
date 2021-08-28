import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CountryServiceProxy, 
  CountryDto,
  CountryEditDto 
} from '@shared/service-proxies/service-proxies';

@Component({ 
  templateUrl: './edit-country-dialog.component.html' 
})
export class EditCountryDialogComponent extends AppComponentBase 
implements OnInit {
  saving = false;
  id: number;
  country = new CountryEditDto();
 
  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _countryService: CountryServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }
  ngOnInit(): void {
    debugger 
    this._countryService
      .getCountryForEdit(this.id)
      .subscribe((result: CountryEditDto) => {
        this.country = result; 
      }); 
  }

  save(): void {
    this.saving = true;

    const country = new CountryDto();
    country.init(this.country);  
    this._countryService.update(country).subscribe(
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
