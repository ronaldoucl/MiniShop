# 🛒 MiniShop - Blazor E-Commerce Application

MiniShop is a simple yet structured e-commerce web application built with **Blazor**, **Entity Framework Core**, and **SQLite**.  
The project demonstrates clean architecture principles, authentication handling, state management, and persistent cart functionality.

---

## 📚 Academic Information

**University:** Brigham Young University Idaho  
**Course:** CSE325 - .NET Software Development  

### 👥 Participants

- Ronaldo Ulises Campos Lucas  
- Jean Lucas Castillo Vasquez  

---

## 🚀 Project Overview

MiniShop simulates a real-world online store where users can:

- Register and log in
- Browse products
- View product details
- Add products to a shopping cart
- View cart summary
- Complete checkout
- Persist orders in a database

The application follows a service-based architecture using dependency injection and state notifications to keep the UI reactive.

---

## 🏗 Architecture & Technologies

### 🖥 Frontend
- Blazor (Interactive Server mode)
- Razor Components
- Component-based UI design
- CSS styling with isolated components

### 🗄 Backend & Data
- Entity Framework Core
- SQLite database
- Code-first approach
- LINQ queries
- Navigation properties with `.Include()` and `.ThenInclude()`

### 🔐 Authentication
- Custom authentication service
- SHA256 password hashing
- Session persistence using browser storage
- Event-based authentication state updates

### 🛒 Cart Management
- Service-based cart logic (`CartService`)
- Automatic cart creation per user
- Dynamic navbar badge updates
- Real-time UI refresh using state change notifications
- Order persistence with status tracking (`Pending`, `Completed`)

---

## 🔄 Application Flow

### 1️⃣ User Authentication
- Users can register with unique email
- Passwords are hashed before storage
- User session is restored on reload

### 2️⃣ Product Browsing
- Products are loaded from the database
- Users can view details per product

### 3️⃣ Cart Logic
- Each authenticated user has one active "Pending" order
- Adding a product:
  - Increases quantity if already exists
  - Adds new item if not
  - Recalculates order total
- Cart item count is dynamically updated

### 4️⃣ Checkout Process
- Validates cart content
- Updates order status to `Completed`
- Saves changes to database
- Redirects to confirmation page

---

## 🧠 Key Design Decisions

- Service layer separation (AuthService, CartService)
- Event-driven UI updates (`OnChange` pattern)
- Defensive programming with error handling
- Console logging for debugging
- Persistent cart stored in database (not in memory)



