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
  StateServiceProxy, 
  StateDto,
  StateEditDto,
  ComboboxItemDto,
  GetComboboxItemOutput
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-state-dialog.component.html'
})
export class EditStateDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  id: number;
  state = new StateEditDto();
  comboboxItems: ComboboxItemDto[] = [];  

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _stateService: StateServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    debugger 
    this._stateService
      .getStateForEdit(this.id)
      .subscribe((result: StateEditDto) => {
        this.state = result; 
      });
    this._stateService
    .getContryLookupItems(0)
    .subscribe((result: GetComboboxItemOutput) => {
      this.comboboxItems = result.comboboxItems; 
      
    });
  } 
  save(): void {
    this.saving = true;

    const state = new StateDto();
    state.init(this.state);  
    this._stateService.update(state).subscribe(
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
