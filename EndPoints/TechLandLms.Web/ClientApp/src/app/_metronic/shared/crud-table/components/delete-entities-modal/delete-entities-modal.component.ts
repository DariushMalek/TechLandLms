import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { of, Subscription } from 'rxjs';
import { catchError, delay, finalize, tap } from 'rxjs/operators';
import { BaseModel, TableService } from '../..';

@Component({
  selector: 'app-delete-entities-modal',
  templateUrl: './delete-entities-modal.component.html',
  styleUrls: ['./delete-entities-modal.component.scss']
})
export class DeleteEntitiesModalComponent<T extends BaseModel> implements OnInit, OnDestroy {
    @Input() ids: number[];
    isLoading = false;
    subscriptions: Subscription[] = [];
    @Input() entityService: TableService<T>;
    errorMessage = "";
    constructor(public modal: NgbActiveModal) { }

  ngOnInit(): void {
  }

    deleteEntities() {
        this.errorMessage = "";
        this.isLoading = true;
        const sb = this.entityService.deleteItems(this.ids).pipe(
            delay(1000), // Remove it from your code (just for showing loading)
            tap(() => this.modal.close()),
            catchError((errorMessage) => {
                this.isLoading = false;
                this.errorMessage = errorMessage.error.errors.$[0];
                if (!this.errorMessage)
                    this.errorMessage = errorMessage.error
                //this.modal.dismiss(errorMessage);
                return of(undefined);
            }),
            finalize(() => {
                this.isLoading = false;
            })
        ).subscribe();
        this.subscriptions.push(sb);
    }

    ngOnDestroy(): void {
        this.subscriptions.forEach(sb => sb.unsubscribe());
    }

}
