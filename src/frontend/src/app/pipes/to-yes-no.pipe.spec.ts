import { ToYesNoPipe } from './to-yes-no.pipe';

describe('ToYesNoPipe', () => {
  it('create an instance', () => {
    const pipe = new ToYesNoPipe();
    expect(pipe).toBeTruthy();
  });
});
