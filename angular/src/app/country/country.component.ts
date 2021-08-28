import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  CountryServiceProxy,
  CountryDto,
  CountryDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateCountryDialogComponent } from './create-country/create-country-dialog.component';
import { EditCountryDialogComponent } from './edit-country/edit-country-dialog.component';

class PagedCountryRequestDto extends PagedRequestDto {
  keyword: string;
}
@Component({ 
  templateUrl: './country.component.html',
  animations: [appModuleAnimation()]
})
export class CountryComponent extends PagedListingComponentBase<CountryDto> {
  countries: CountryDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _countryService: CountryServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedCountryRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
debugger
    this._countryService
      .getAll(request.keyword, request.skipCount, request.maxResultCount)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: CountryDtoPagedResultDto) => {
        this.countries = result.items;
        this.showPaging(result, pageNumber);
      });
  }
  delete(country: CountryDto): void {
    abp.message.confirm(
      this.l('CountryDeleteWarningMessage', country.name),
      undefined,
      (result: boolean) => {
        if (result) {
          this._countryService
            .delete(country.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => {});
        }
      }
    );
  }

  createCountry(): void {
    this.showCreateOrEditCountryDialog();
  }

  editCountry(country: CountryDto): void {
    this.showCreateOrEditCountryDialog(country.id);
  }

  showCreateOrEditCountryDialog(id?: number): void {
    let createOrEditCountryDialog: BsModalRef;
    if (!id) {
      createOrEditCountryDialog = this._modalService.show(
        CreateCountryDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditCountryDialog = this._modalService.show(
        EditCountryDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditCountryDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
} 