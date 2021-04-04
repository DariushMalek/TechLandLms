import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { DynamicAsideMenuConfig } from '../../configs/dynamic-aside-menu.config';

const emptyMenuConfig = {
  items: []
};

@Injectable({
  providedIn: 'root'
})
export class DynamicAsideMenuService {
  private menuConfigSubject = new BehaviorSubject<any>(emptyMenuConfig);
  menuConfig$: Observable<any>;
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.menuConfig$ = this.menuConfigSubject.asObservable();
    this.loadMenu();
  }

    getMenuFromServer(): Observable<any> {
        const url = this.baseUrl + 'MenuConfig/GetMenuItems';
        return this.http.get<any>(url);
    }
  // Here you able to load your menu from server/data-base/localStorage
  // Default => from DynamicAsideMenuConfig
    private loadMenu() {
        this.getMenuFromServer().subscribe(data => {
            this.setMenu(data);
        }, error => {
                console.log(error);
        })
    
  }

  private setMenu(menuConfig) {
    this.menuConfigSubject.next(menuConfig);
  }

  private getMenu(): any {
    return this.menuConfigSubject.value;
  }
}
