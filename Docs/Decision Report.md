# Feature Patterns and Implementation Plan

---

## Feature 1: Customer Account Management

### Pattern
`synchronous communication (request–response)`

### Reasoning
- High dependencies between stages of logging in (can't skip any)
- Need immediate response for request
- Data consistency

### Trade-offs
- Latency: user may experience slowness if the server is busy, as each process must finish before moving to the next

### Alternatives Considered
- None

### Implementation Details
- TBD

---

## Feature 2: Order Tracking for Customer

### Pattern
`Short Polling`

### Reasoning
- Order status updates should feel real-time but don’t need to be instant

### Trade-offs
- Clients poll even when no status change occurs
- Polling every 30s–2m can generate heavy traffic

### Alternatives Considered
- Why not `SSE`? (instant updates not needed)

### Implementation Details
- TBD

---

## Feature 3: Driver Location Updates

### Pattern
`Server-Sent Events (SSE)`

### Reasoning
- Almost real-time, one-way direction (driver sends location)
- Supports auto-reconnection for unstable connections

### Trade-offs
- More complex
- Requires browser support

### Alternatives Considered
- Why not `WebSockets`? (more complex, unnecessary for one-way updates, not ideal on bad networks)

### Implementation Details
- TBD

---

## Feature 4: Restaurant Order Notifications (Customer → Restaurant)

### Pattern
`Server-Sent Events (SSE)`

### Reasoning
- Almost real-time, one-way direction (customer sends order)
- Auto-reconnection for unstable connections

### Trade-offs
- More complex
- Requires browser support

### Alternatives Considered
- Why not `WebSockets`? (more complex, unnecessary for one-way updates)

### Implementation Details
- TBD

---

## Feature 5: Restaurant Order Notifications (Restaurant ↔ Customer)

### Pattern
`WebSockets`

### Reasoning
- Almost real-time
- Bidirectional channel

### Trade-offs
- More complex
- Requires browser support

### Alternatives Considered
- Why not `SSE`? (only one-way push)

### Implementation Details
- TBD

---

## Feature 6: System-Wide Announcement

### Pattern
`Publish-Subscribe (Pub/Sub) with Server-Sent Events (SSE)`

### Reasoning
- `Pub/Sub`: real-time delay is acceptable
- `SSE`: one-way push

### Trade-offs
- None

### Alternatives Considered
- Why not `WebSockets` with Pub/Sub? (more complex, unnecessary for one-way updates)

### Implementation Details
- TBD

---

## Feature 7: Image Upload for Menu Items

### Pattern
`Long Polling`

### Reasoning
- Reduces unnecessary calls
- Provides near real-time updates

### Trade-offs
- Each client holds an open connection

### Alternatives Considered
- Why not `Short Polling`? (many empty requests)

### Implementation Details
- TBD
