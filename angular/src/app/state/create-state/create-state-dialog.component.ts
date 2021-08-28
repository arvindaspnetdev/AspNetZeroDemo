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
  StateServiceProxy,
  StateDto, 
  CreateStateDto,
  ComboboxItemDto,
  GetComboboxItemOutput
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  templateUrl: 'create-state-dialog.component.html'
})
export class CreateStateDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  state = new StateDto();
  comboboxItems: ComboboxItemDto[]=[];

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
      .getContryLookupItems(0)
      .subscribe((result: GetComboboxItemOutput) => {
        this.comboboxItems = result.comboboxItems; 
      });
  }

  save(): void {
    this.saving = true;
    const state = new CreateStateDto();
    state.init(this.state);

    this._stateService
      .create(state)
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
