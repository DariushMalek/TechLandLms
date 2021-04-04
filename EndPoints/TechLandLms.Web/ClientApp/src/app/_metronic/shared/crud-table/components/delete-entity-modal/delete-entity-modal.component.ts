import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { of, Subscription } from 'rxjs';
import { catchError, delay, finalize, tap } from 'rxjs/operators';
import { BaseModel, TableService } from '../..';

@Component({
  selector: 'app-delete-entity-modal',
  templateUrl: './delete-entity-modal.component.html',
  styleUrls: ['./delete-entity-modal.component.scss']
})
export class DeleteEntityModalComponent<T extends BaseModel> implements OnInit, OnDestroy {
    @Input() id: number;
    isLoading = false;
    subscriptions: Subscription[] = [];
    @Input() entityService: TableService<T>;
    errorMessage = "";
    constructor(public modal: NgbActiveModal) { }

  ngOnInit(): void {
  }
    deleteEntity() {
        this.isLoading = true;
        const sb = this.entityService.delete(this.id).pipe(
            delay(1000), // Remove it from your code (just for showing loading)
            tap(() => this.modal.close()),
            catchError((err) => {
                this.isLoading = false;
                this.errorMessage = err.error.errors.$[0];
                if (!this.errorMessage)
                    this.errorMessage = err.error
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
