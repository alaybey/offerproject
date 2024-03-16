import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-offer-table',
  standalone: true,
  imports: [
    CommonModule,
  ],
  template: `<p>OfferTable works!</p>`,
  styleUrl: './OfferTable.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class OfferTableComponent { }
