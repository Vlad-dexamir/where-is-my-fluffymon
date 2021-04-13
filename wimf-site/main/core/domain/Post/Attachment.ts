export interface Attachment {
  readonly filename: string;
  readonly fileSize: number;
  readonly path: string;
  readonly tags?: string[];
}
