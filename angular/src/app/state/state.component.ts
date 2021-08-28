import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  StateServiceProxy,
  StateDto,
  StateDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';
import { CreateStateDialogComponent } from './create-state/create-state-dialog.component';
import { EditStateDialogComponent } from './edit-state/edit-state-dialog.component';
class PagedStateRequestDto extends PagedRequestDto {
  keyword: string;
}
@Component({ 
  templateUrl: './state.component.html',
  animations: [appModuleAnimation()]
}) 

export class StateComponent extends PagedListingComponentBase<StateDto> {
  states: StateDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _stateService: StateServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedStateRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._stateService
      .getAll(request.keyword, request.skipCount, request.maxResultCount)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: StateDtoPagedResultDto) => {
        this.states = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(state: StateDto): void {
    abp.message.confirm(
      this.l('CountryDeleteWarningMessage', state.stateName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._stateService
            .delete(state.id)
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

  createState(): void {
    this.showCreateOrEditStateDialog();
  }

  editState(state: StateDto): void {
    this.showCreateOrEditStateDialog(state.id);
  }

  showCreateOrEditStateDialog(id?: number): void {
    let createOrEditStateDialog: BsModalRef;
    if (!id) {
      createOrEditStateDialog = this._modalService.show(
        CreateStateDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditStateDialog = this._modalService.show(
        EditStateDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditStateDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
} 