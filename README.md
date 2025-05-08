# Car Dealership Decorator Pattern

## 💡 Why Decorator Pattern?

In real-world scenarios like car dealerships, cars come in standard models but can be enhanced with optional features. The Decorator pattern allows us to:

- Add features **without changing the base class**.
- Combine multiple add-ons **at runtime**.
- Keep the codebase **flexible and maintainable**.

Instead of creating multiple subclasses (e.g., `SedanWithSunroofAndLeather`), we **compose features dynamically** using decorators.



| **Part**                | **Class/Role**                                                       | **Responsibility**                                                |
| ----------------------- | -------------------------------------------------------------------- | ----------------------------------------------------------------- |
| **Component Base**      | `ICar`                                                               | The base interface for all cars and decorators.                   |
| **Concrete Component**  | `Sedan`, `SUV`                                                       | Basic car types.                                                  |
| **Decorator Base**      | `CarDecorator`                                                       | Abstract class that wraps `ICar` and allows dynamic extension.    |
| **Concrete Decorators** | `SunroofDecorator`, `LeatherSeatsDecorator`, `PremiumSoundDecorator` | Add specific features by extending the base.                      |
| **Client**              | `Program`                                                            | Lets the user build a car by choosing base + add-ons dynamically. |
