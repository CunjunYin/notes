# Introduction
When we deal with an event-driven system, event can be fired many times in a very short timeframe. In this circumstance, we need an elegant way to deal with it, and the result in a performance increase for our software.

## Example  by David Corbacho
As we can see, by one mosuse whell scroll, events can be trigged multiple times. 
<iframe src="https://codepen.io/dcorb/pen/PZOZgB"></iframe>

We can imagine if a complex calculation is done directly after the scroll event, the software will likely crash, and result in a bad user experience.

To dealing with problem discribe above, sophisticated methods were introduced to handling consecutive fast events

## 1. Debounce
Group multiple events into a signle event. The `signle event` will only fired if and only if in a timeframe the event did not fire again.

![Tux, the Linux mascot](https://github.com/CunjunYin/notes/tree/main/Web/assets/Debounce.jpg)

#### Playground
<iframe src="https://codepen.io/dcorb/pen/KVxGqN"></iframe>

When applying debounce methodology to software, developers can either use `Leading` or `Trailing` implementation to suit the software requirements. The example above is Tailing - triggering function until the events stop firing.

[Debounce source code by Lodash](https://github.com/lodash/lodash/blob/2f79053d7bc7c9c9561a30dda202b3dcd2b72b90/debounce.js)

## 2. Throttle
Throttle is a methodology to guarantees a function will only be triggered once in a timeframe, by slows down the the flow of the event.

![Tux, the Linux mascot](https://github.com/CunjunYin/notes/tree/main/Web/assets/Throttle.jpg)

[Throttle source code by Lodash](https://github.com/lodash/lodash/blob/2f79053d7bc7c9c9561a30dda202b3dcd2b72b90/throttle.js)


# Reference
[Debouncing and Throttling Explained Through Examples](https://css-tricks.com/debouncing-throttling-explained-examples)