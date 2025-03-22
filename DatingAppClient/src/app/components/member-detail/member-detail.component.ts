import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Member } from '../../models/member';
import { MembersService } from '../../services/members.service';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { GalleryItem, GalleryModule, ImageItem } from 'ng-gallery';

@Component({
  standalone: true,
  selector: 'app-member-detail',
  imports: [TabsModule, GalleryModule],
  templateUrl: './member-detail.component.html',
  styleUrl: './member-detail.component.css',
})
export class MemberDetailComponent implements OnInit {
  ngOnInit(): void {
    this.loadMember();
  }
  private memeberService = inject(MembersService);
  router = inject(ActivatedRoute);
  member?: Member;
  images: GalleryItem[] = [];

  loadMember() {
    const userName = this.router.snapshot.paramMap.get('username');
    if (!userName) return;

    this.memeberService.getMember(userName).subscribe({
      next: member => {
        this.member = member;
        member.photos.map(p => {
          this.images.push(new ImageItem({ src: p.url, thumb: p.url }));
        });
      },
    });
  }
}
